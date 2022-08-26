namespace MundoBalloonApi.test.GraphQL.Fixtures;

public static class Fragments
{
    private const string ProductSimpleCard = @"
        fragment CategoryName on ProductCategory {
            name
        }

        fragment MediaUrlAndType on ProductVariantMedium {
            url
            mediaType
        }

        fragment ProductVariantsMediaOnly on ProductVariant {
            media {
                ...MediaUrlAndType
            }
        }

        fragment ProductVariantsReview on ProductVariant {
            reviews {
                rating
            }
        }

        fragment ProductSimpleCard on Product {
            productId
            name
            category {
                ...CategoryName
            }
            price
            variants {
                ...ProductVariantsMediaOnly
                ...ProductVariantsReview
            }
        }
    ";

    public const string ProductsDictionaryFragment = ProductSimpleCard + @"
        fragment ProductsDictionary on KeyValuePairOfStringAndListOfProduct {
          key
          value {
            ...ProductSimpleCard
          }
        }
    ";
}